"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var platform_browser_dynamic_1 = require("@angular/platform-browser-dynamic");
var person_module_1 = require("./person/person.module");
var todo_module_1 = require("./todo/todo.module");
var platform = platform_browser_dynamic_1.platformBrowserDynamic();
platform.bootstrapModule(todo_module_1.TodoModule);
platform.bootstrapModule(person_module_1.PersonModule);
//# sourceMappingURL=main.js.map