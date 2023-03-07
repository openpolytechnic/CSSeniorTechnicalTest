/** @type {import('tailwindcss').Config} */
module.exports = {
    /*purge: [],*/
    darkMode: false,
    content: [
        "./src/**/*.{js,jsx,ts,tsx}"
    ],
    theme: {
        extend: {
            colors: {
                insideEdge: "#ff0000",
                black: "#393939"
            },
            fontSize: {
                '4.5xl': '2.5rem'
            },
            skew: {
                '-7': '-7deg',
                '-20': '-20deg'
            },
            borderWidth: {
                10: '10px'
            },
            transitionTimingFunction: {
                'bloop': "cubic-bezier(1, -0.65, 0, 2.31",
            },
            width: {
                '800': "800px",
                '210': "210px"
            }
        },
    },
    variants: {
        extend: {
            scale: ["group-hover"]
        }
    },
    plugins: [],
}
