import Vue from "vue";
import { ValidationProvider, ValidationObserver, extend } from "vee-validate";
/* eslint-disable @typescript-eslint/camelcase */
import {
  required,
  email,
  confirmed,
  min,
  alpha_num,
  min_value,
  max,
} from "vee-validate/dist/rules";

//import rules
extend("email", {
  ...email,
  message: "{_field_} field is not a valid email.",
});
extend("required", {
  ...required,
  message: "{_field_} field is required.",
});
extend("confirmed", {
  ...confirmed,
  message: "{_field_} field does not match the {target} field.",
});
extend("alpha_num", {
  ...alpha_num,
  message: "{_field_} field should only have alphanumeric characters.",
});
extend("min", {
  ...min,
  message: "{_field_} field must have a minimum length of {length}.",
});
extend("max", {
  ...max,
  message: "{_field_} field must have a maximum length of {length}.",
});
extend("min_value", {
  ...min_value,
  message: "{_field_} field must have a minimum value of {min}.",
});

// Add a rule.
extend("less_than", {
  params: ["target"],
  validate(value, params: Record<string, any>) {
    if (value == null || params["target"] == null) return true;
    return value <= params["target"];
  },
  message: "{_field_} must be less than the {target}.",
});
extend("greater_than", {
  params: ["target"],
  validate(value, params: Record<string, any>) {
    if (value == null || params["target"] == null) return true;
    return value >= params["target"];
  },
  message: "{_field_} must be greater than {target}.",
});

Vue.component("validation-provider", ValidationProvider);
Vue.component("validation-observer", ValidationObserver);
