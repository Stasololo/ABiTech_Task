import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { PersonModule } from './person/person.module';
import { TodoModule } from './todo/todo.module';

const platform = platformBrowserDynamic();
platform.bootstrapModule(TodoModule);
platform.bootstrapModule(PersonModule);