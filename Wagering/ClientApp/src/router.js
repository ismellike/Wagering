import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import {
  LoginActions,
  LogoutActions,
  ApplicationPaths
} from './auth/AuthConstants'
import Login from './auth/Login'
import Logout from './auth/Logout'
import store from './store'

Vue.use(Router)

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [{
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/protected',
      name: 'protected',
      component: () => import('./views/Protected.vue'),
      meta: {
        requiresAuth: true
      }
    }, //Auth Routes
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
        action: LogoutActions.LogOut
      }
    },
    {
      path: ApplicationPaths.LogOutCallback,
      component: Logout,
      props: {
        action: LogoutActions.LogOutCallback
      }
    },
    {
      path: ApplicationPaths.LoggedOut,
      component: Logout,
      props: {
        action: LogoutActions.LoggedOut
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (store.state.account.isAuthenticated) {
      next()
    } else {
      next({
        path: ApplicationPaths.Login
      })
    }
  } else {
    next()
  }
})

export default router