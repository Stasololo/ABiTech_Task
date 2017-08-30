import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { APP_BASE_HREF } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { TodoComponent } from "./components/todo.component";
import { PersonComponent } from "./components/person.component";
@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule, ReactiveFormsModule, routing],
    declarations: [AppComponent, TodoComponent, PersonComponent],
    bootstrap: [AppComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }]
})
export class AppModule { }