import Vue from "vue";
import Router from "vue-router";
import Home from "@/views/Home.vue";
import {
	LoginActions,
	LogoutActions,
	ApplicationPaths
} from "@/constants/authentication";
import Login from "@/views/authentication/Login";
import Logout from "@/views/authentication/Logout";
import store from "@/store";

Vue.use(Router);

const routes = [
	{
		path: "*",
		name: "home",
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
		path: "/host-panel/wagers/pending/:id",
		name: "wager_pending",
		component: () => import("@/views/control/host/wagers/Pending.vue"),
		meta: {
			requiresAuth: true
		}
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
		path: ApplicationPaths.Login,
		component: Login,
		props: {
			action: LoginActions.Login
		},
		beforeEnter: (to, from, next) => {
			if (to.query.returnUrl == null && to.name != from.name && from.name != "home")
				next({
					path: ApplicationPaths.Login,
					query: { returnUrl: window.location.href }
				});
			else next();
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
		},
		beforeEnter: (to, from, next) => {
			if (to.query.returnUrl == null && to.name != from.name && from.name != "home")
				next({
					path: ApplicationPaths.Register,
					query: { returnUrl: window.location.href }
				});
			else next();
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
				path: ApplicationPaths.Login,
				query: { returnUrl: from.path }
			});
		}
	} else {
		next();
	}
});

export default router;
