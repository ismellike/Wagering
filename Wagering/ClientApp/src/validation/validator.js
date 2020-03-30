import Vue from "vue";
import {
	ValidationProvider,
	ValidationObserver,
	extend
} from "vee-validate";
import {
	required,
	email,
	confirmed,
	min,
	alpha_num
} from "vee-validate/dist/rules";

//import rules
extend("email", {
	...email,
	message: "{_field_} field is not a valid email."
});
extend("required", {
	...required,
	message: "{_field_} field is required."
});
extend("confirmed", {
	...confirmed,
	message: "{_field_} field does not match the {target} field."
});
extend("alpha_num", {
	...alpha_num,
	message: "{_field_} field should only have alphanumeric characters."
});
extend("min", {
	...min,
	message: "{_field_} field must have a minimum length of {length}."
});

// Add a rule.
extend("less_than", {
	params: ["target"],
	validate(value, {
		target
	}) {
		if (value === null || target === null) return true;
		return value <= target;
	},
	message: "{_field_} must be less than the {target}."
});
extend("greater_than", {
	params: ["target"],
	validate(value, {
		target
	}) {
		if (value === null || target === null) return true;
		return value >= target;
	},
	message: "{_field_} must be greater than {target}."
});
extend("min_amount", {
	validate: value => value > .01,
	message: "The minimum amount is .01"
});

// Register it globally
Vue.component("ValidationProvider", ValidationProvider);
Vue.component("ValidationObserver", ValidationObserver);