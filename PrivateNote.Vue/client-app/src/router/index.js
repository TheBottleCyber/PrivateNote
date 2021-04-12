import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Create from '../views/Create.vue'
import Get from '../views/Get.vue'

const routes = [
  { path: '/', name: 'Home', component: Home },
  { path: '/create', name: 'Create', component: Create },
  { path: '/get', name: 'Get', component: Get }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
