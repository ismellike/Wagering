module.exports = {
    root: true,
    env: {
        node: true,
    },
    extends: ["plugin:vue/essential", "@vue/typescript", "eslint:recommended"],
    parserOptions: {
        parser: "@typescript-eslint/parser",
        sourcetype: "module",
    },
    rules: {
        "no-console": process.env.NODE_ENV === "production" ? "warn" : "off",
        "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off",
        "no-unused-vars": "off",
    },
};
