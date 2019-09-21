/*https://github.com/manjumjn/gulp-with-tailwindcss/blob/master/gulpfile.js*/

const { src, dest, series, parallel } = require('gulp');
const options = require("./package.json").options; //Options : paths and other options from package.json
const postcss = require('gulp-postcss');    //For Compiling tailwind utilities with tailwind config
const concat = require('gulp-concat');      //For Concatinating js,css files
const del = require('del');                 //For Cleaning build/dist for fresh export
const logSymbols = require('log-symbols');  //For Symbolic Console logs :) :P
const imagemin = require('gulp-imagemin');  //To Optimize Images
const purgecss = require('gulp-purgecss');  //To Remove Unsued CSS
const cleanCSS = require('gulp-clean-css'); //To Minify CSS files
const webp = require('gulp-webp'); //For converting images to WebP format
const replace = require('gulp-replace'); //For Replacing img formats to webp in html

const cleanDevelopmentPath = function (cb) {
    console.log("\n\t" + logSymbols.info, "Cleaning development build folder for fresh start.\n");
    return del([options.paths.dist.base + '/**/*']);
};

function cleanBuildPath(cb) {

    console.log("\n\t" + logSymbols.info, "Cleaning build folder for fresh start.\n");
    return del([options.paths.dist.base + '/**/*']);
}

const developmentHtml = function (cb) {
    return src(options.paths.src.base + '/**/*.html')
        .pipe(dest(options.paths.dist.base));
};

const buildHtml = function (cb) {
    return src(options.paths.src.base + '/**/*.html')
        .pipe(dest(options.paths.build.base));
};


const developmentStyles = function (cb) {
    var tailwindcss = require('tailwindcss');
    var autoprefixer = require('autoprefixer');
    var postCssImport = require('postcss-import');
    return src(options.paths.src.css + '/main.css')
        .pipe(postcss(
            [
                postCssImport,
                tailwindcss(options.config.tailwindcss),
                autoprefixer
            ]
        ))
        .pipe(concat({ path: 'main.css' }))
        .pipe(dest(options.paths.dist.css));
};

const buildStyles = function (cb) {
    return src(options.paths.dist.css + '/**/*')
        .pipe(purgecss({
            content: ["src/**/*.html", "src/**/.*js"],
            extractors: [{
                extractor: TailwindExtractor,
                extensions: ['html']
            }]
        }))
        .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(dest(options.paths.build.css));
};

const developmentScript = function (cb) {
    return src([options.paths.src.js + '/libs/**/*.js', options.paths.src.js + '/**/*.js'])
        .pipe(concat({ path: 'main.js' }))
        .pipe(dest(options.paths.dist.js));
};

const buildScript = function () {
    return src([options.paths.src.js + '/libs/**/*.js', options.paths.src.js + '/**/*.js'])
        .pipe(concat({ path: 'main.js' }))
        .pipe(uglify())
        .pipe(dest(options.paths.build.js));
};

const developmentImage = function () {
    return src(options.paths.src.img + '/**/*')
        .pipe(webp({ quality: 100 }))
        .pipe(dest(options.paths.dist.img));
};

const buildImage = function (cb) {
    return src(options.paths.src.img + '/**/*')
        .pipe(webp({ quality: 100 }))
        .pipe(imagemin())
        .pipe(dest(options.paths.build.img));

};

exports.default = series(cleanDevelopmentPath, parallel(developmentStyles, developmentScript, developmentImage, developmentHtml), (done) => {
    console.log("\n\t" + logSymbols.info, "npm run dev is complete. Files are located at " + options.paths.dist.base + "\n");
    done();
});

exports.build = series(cleanBuildPath, parallel(buildStyles, buildScript, buildImage, buildHtml), (done) => {
    console.log("\n\t" + logSymbols.info, "npm run build is complete. Files are located at " + options.paths.dist.base + "\n");
    done();
});
