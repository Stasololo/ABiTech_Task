"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var todo_component_1 = require("./components/todo.component");
var person_component_1 = require("./components/person.component");
var status_component_1 = require("./components/status.component");
var appRoutes = [
    { path: '', redirectTo: 'todo', pathMatch: 'full' },
    { path: 'todo', component: todo_component_1.TodoComponent },
    { path: 'person', component: person_component_1.PersonComponent },
    { path: 'status', component: status_component_1.StatusComponent }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map