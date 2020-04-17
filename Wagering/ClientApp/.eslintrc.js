module.exports = {
  root: true,
  env: {
    node: true
  },
    extends: ["plugin:vue/essential", "eslint:recommended"],
  parser: "vue-eslint-parser",
  parserOptions: {
      parser: "babel-eslint",
      sourceType: "module"
  },
  rules: {
    "no-console": process.env.NODE_ENV === "production" ? "error" : "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "error" : "off"
  }
};