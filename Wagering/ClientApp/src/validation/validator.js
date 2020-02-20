import Vue from "vue";
import { ValidationProvider, extend } from "vee-validate";
import {
  required,
  email,
  confirmed,
  min_value,
  alpha_num
} from "vee-validate/dist/rules";

//import rules
extend("email", email);
extend("required", required);
extend("confirmed", confirmed);
extend("min_value", {
  ...min_value,
  message: "{_field_} must be greater than {min}."
});
extend("alpha_num", alpha_num);

// Add a rule.
extend("less_than", {
  params: ["target"],
  validate(value, { target }) {
    if (value === null || target === null) return true;
    return value <= target;
  },
  message: "{_value_} must be less than the {target}."
});
extend("greater_than", {
  params: ["target"],
  validate(value, { target }) {
    if (value === null || target === null) return true;
    return value >= target;
  },
  message: "{_value_} must be greater than {target}."
});

// Register it globally
Vue.component("ValidationProvider", ValidationProvider);
