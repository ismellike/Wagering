module.exports = {
	"devServer": {
		"progress": false,
		"liveReload": true
	},
	"pages": {
		"app": {
			"entry": "src/main.js",
			"template": "public/index.html",
			"filename": "index.html"
		}
	},
	"publicPath": "/",
	"transpileDependencies": [
		"vuetify"
	]
}