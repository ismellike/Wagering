module.exports = {
    devServer: {
        progress: false,
        liveReload: true,
        public: "localhost:8080",
    },
    pages: {
        app: {
            entry: "src/main.ts",
            template: "public/index.html",
            filename: "index.html",
        },
    },
    pwa: {
        name: "Wagering.gg",
        themeColor: "#673AB7",
        msTileColor: "#00ACC1",
    },
    transpileDependencies: ["vuetify"],
};
