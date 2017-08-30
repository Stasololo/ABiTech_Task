"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var todo_component_1 = require("./components/todo.component");
var person_component_1 = require("./components/person.component");
var appRoutes = [
    { path: '', redirectTo: 'todo', pathMatch: 'full' },
    { path: 'todo', component: todo_component_1.TodoComponent },
    { path: 'person', component: person_component_1.PersonComponent }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map