// tailwind.config.js
module.exports = {
    important: true,
    theme: {
        colors: {
            transparent: 'transparent',
            black: '#000',
            white: '#fff',
            twistedcloud: {
                red: '#ef2637',
                gray: '#5a5a5f',
                grey: '#5a5a5f',
                purple: '#94368d',
                yellow: '#ffcc00',
                teal: '#00b4bf'
            },
            gray: {
                100: '#f2f2f2',
                500: '#adadad',
                900: '#333'
            },
            yellow: {
                100: '#f5f39f'
            },
            'dark-blue': '#190c7a',
            'medium-blue': '#8cccce',
            'dark-red': '#970000'
        },
        fontFamily: {
            display: ['Avenir Next LT Pro', 'Arial', 'Helvetica Neue', 'Helvetica', 'sans-serif'],
            body: ['Avenir Next LT Pro', 'Arial', 'Helvetica Neue', 'Helvetica', 'sans-serif']
        },
        elements: {
            'headerHeight': '56px',
            'navWidth': '56px'
        },
        extend: {
            spacing: {
                '72': '18rem',
                '80': '20rem',
                '88': '22rem',
                '96': '24rem',
            },
        }
    },
    variants: {},
    plugins: [

        // add flex-basis utilities
        function ({ addUtilities, theme }) {

            const spacing = theme('spacing');
            Object.keys(spacing).forEach(key => {
                const spacingKey = key;
                const spacingValue = spacing[key];
                addUtilities({
                    [`.flex-basis-${spacingKey}`]: {
                        'flex-basis': spacingValue
                    },
                    [`.flex-0-0-${spacingKey}`]: {
                        'flex': `0 0 ${spacingValue}`
                    }
                });
            })
        },

        // add px height and width from 1 - 100
        function ({ addUtilities }) {
            [...Array(300).keys()].forEach(index => {
                const num = index + 1;
                addUtilities({
                    [`.h-${num}px`]: {
                        'height': `${num}px`
                    },
                    [`.w-${num}px`]: {
                        'width': `${num}px`
                    }
                });
            });
        },

        // add stroke-color and fill-color
        function ({ addUtilities, theme, e }) {

            const colors = theme('colors');
            Object.keys(colors).forEach(key => {
                const colorKey = key;
                const colorValue = colors[key];
                if (typeof colorValue === 'string') {
                    addUtilities({
                        [`.stroke-${colorKey}`]: {
                            'stroke': colorValue
                        },
                        [`.${e(`hover\:stroke-${colorKey}`)}:hover`]: {
                            'stroke': colorValue
                        },
                        [`.fill-${colorKey}`]: {
                            'fill': colorValue
                        },
                        [`.${e(`hover\:fill-${colorKey}`)}:hover`]: {
                            'fill': colorValue
                        }
                    });
                } else {
                    const parentKey = colorKey;
                    const subColors = colorValue;
                    Object.keys(subColors).forEach(key => {
                        const subKey = key;
                        const subValue = subColors[key];
                        addUtilities({
                            [`.stroke-${parentKey}-${subKey}`]: {
                                'stroke': subValue
                            },
                            [`.${e(`hover\:stroke-${parentKey}-${subKey}`)}:hover`]: {
                                'stroke': subValue
                            },
                            [`.fill-${parentKey}-${subKey}`]: {
                                'fill': subValue
                            },
                            [`.${e(`hover\:fill-${parentKey}-${subKey}`)}:hover`]: {
                                'fill': subValue
                            }
                        });
                    });
                }
            })
        },

        // misc. custom classes
        function ({ addUtilities, theme }) {
            addUtilities({
                '.rotate-90': { 'transform': 'rotate(90deg)' },
                '.rotate-180': { 'transform': 'rotate(180deg)' },
                '.rotate-270': { 'transform': 'rotate(270deg)' },
                '.absolute-center-y': {
                    'top': '50%',
                    'transform': 'translateY(-50%)'
                },
                '.absolute-center-x': {
                    'left': '50%',
                    'transform': 'translateX(-50%)'
                },
                '.header-height': {
                    'height': theme('headerHeight')
                }
            });
        }
    ],
}