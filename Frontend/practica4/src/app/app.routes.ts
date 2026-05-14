import { Routes } from '@angular/router';

import { Chefs } from './features/chefs/page/chefs';
import { Recipes } from './features/recipes/page/recipes';
import { Home } from './features/home/home';


export const routes: Routes = [

    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: Home
    },

    {
        path: 'chefs',
        component: Chefs
    },

    {
        path: 'recipes',
        component: Recipes
    },

    {
        path: '**',
        redirectTo: 'home'
    }

];