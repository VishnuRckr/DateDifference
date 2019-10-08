import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { PersonPetsModule } from './app/Person-Pets/Person-Pets.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(PersonPetsModule)
  .catch(err => console.error(err));
