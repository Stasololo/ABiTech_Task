import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TodoComponent } from "./components/todo.component";
import { PersonComponent } from "./components/person.component";
const appRoutes: Routes = [
    { path: '', redirectTo: 'todo', pathMatch: 'full' },
    { path: 'todo', component: TodoComponent },
    { path: 'person', component: PersonComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);