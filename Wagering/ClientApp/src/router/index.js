import Vue from "vue";
import Router from "vue-router";
import Home from "@/views/Home.vue";
import {
	LoginActions,
	LogoutActions,
	ApplicationPaths
} from "@/auth/AuthConstants";
import Login from "@/auth/Login";
import Logout from "@/auth/Logout";
import store from "@/store";

Vue.use(Router);

const routes = [
	{
		path: "*",
		component: Home
	},
	{
		path: "/about",
		component: () => import("@/views/About.vue")
	},
	{
		path: "/hub",
		component: () => import("@/views/Hub.vue")
	},
	{
		path: "/host-panel",
		component: () => import("@/views/control/host/Main.vue"),
		meta: {
			requiresAuth: true
		},
		children: [
			{
				path: "wagers",
				component: () => import("@/views/control/host/wagers/Main.vue")
			},
			{
				path: "tournaments",
				component: () => import("@/views/control/host/tournaments/Main.vue")
			},
			{
				path: "leagues",
				component: () => import("@/views/control/host/leagues/Main.vue")
			}
		]
	},
	{
		path: "/host-panel/wagers/edit/:id",
		name: "wager_edit",
		component: () => import("@/views/control/host/wagers/Edit.vue")
	},
	{
		path: "/client-panel",
		component: () => import("@/views/control/client/Main.vue"),
		meta: {
			requiresAuth: true
		},
		children: [
			{
				path: "wagers",
				component: () => import("@/views/control/client/wagers/Main.vue")
			},
			{
				path: "tournaments",
				component: () => import("@/views/control/client/tournaments/Main.vue")
			},
			{
				path: "leagues",
				component: () => import("@/views/control/client/leagues/Main.vue")
			}
		]
	}, // wagers
	{
		path: "/:game/wagers",
		name: "wagers",
		component: () => import("@/views/wagers/Main.vue")
	},
	{
		path: "/:game/wagers/create",
		name: "wager_create",
		component: () => import("@/views/wagers/Create.vue")
	},
	{
		path: "/:game/wagers/:id",
		name: "wager_view",
		component: () => import("@/views/wagers/View.vue")
	},
	{
		path: "/profiles/:name",
		name: "profile_view",
		component: () => import("@/views/profiles/View.vue")
	}, //Auth Routes
	{
		path: "/register",
		name: "register",
		component: () => import("@/views/control/Register.vue")
	},
	{
		path: ApplicationPaths.Login,
		component: Login,
		props: {
			action: LoginActions.Login
		}
	},
	{
		path: ApplicationPaths.LoginFailed,
		component: Login,
		props: {
			action: LoginActions.LoginFailed
		}
	},
	{
		path: ApplicationPaths.LoginCallback,
		component: Login,
		props: {
			action: LoginActions.LoginCallback
		}
	},
	{
		path: ApplicationPaths.Profile,
		component: Login,
		props: {
			action: LoginActions.Profile
		},
		meta: {
			requiresAuth: true
		}
	},
	{
		path: ApplicationPaths.Register,
		component: Login,
		props: {
			action: LoginActions.Register
		}
	},
	{
		path: ApplicationPaths.LogOut,
		component: Logout,
		props: {
			action: LogoutActions.Logout
		}
	},
	{
		path: ApplicationPaths.LogOutCallback,
		component: Logout,
		props: {
			action: LogoutActions.LogoutCallback
		}
	},
	{
		path: ApplicationPaths.LoggedOut,
		component: Logout,
		props: {
			action: LogoutActions.LoggedOut
		}
	}
];

const router = new Router({
	mode: "history",
	base: process.env.BASE_URL,
	routes
});

router.beforeEach((to, from, next) => {
	if (to.matched.some(record => record.meta.requiresAuth)) {
		if (store.state.account.isAuthenticated) {
			next();
		} else {
			next({
				path: ApplicationPaths.Login
			});
		}
	} else {
		next();
	}
});

export default router;
