import { Routes } from '@angular/router';

import { Students } from './features/students/students';
import { Courses } from './features/courses/courses';

export const routes: Routes = [

    {
        path: '',
        redirectTo: 'students',
        pathMatch: 'full'
    },

    {
        path: 'students',
        component: Students
    },

    {
        path: 'courses',
        component: Courses
    },

    {
        path: '**',
        redirectTo: 'students'
    }

];