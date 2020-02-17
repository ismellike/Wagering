module.exports = {
  devServer: {
    port: 44344
  },
  pages: {
    app: {
      entry: 'src/main.js',
      template: 'public/index.html',
      filename: 'index.html'
    }
  },
  publicPath: '/'
};