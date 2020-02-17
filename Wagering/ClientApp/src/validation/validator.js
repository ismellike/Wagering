import Vue from "vue";
import { ValidationProvider, extend } from "vee-validate";
import { required, email, confirmed, min_value } from "vee-validate/dist/rules";

//import rules
extend("email", email);
extend("required", required);
extend("confirmed", confirmed);
extend("min_value", min_value);

// Add a rule.
extend("min_wager", {
  params: ["target"],
  validate(value, { target }) {
    if (value === null || target === null) return true;
    return value < target;
  },
  message: "The minimum wager must be less than the maximum wager."
});
extend("max_wager", {
  params: ["target"],
  validate(value, { target }) {
    if (value === null || target === null) return true;
    return value > target;
  },
  message: "The maximum wager must be less than the minimum wager."
});

// Register it globally
Vue.component("ValidationProvider", ValidationProvider);
