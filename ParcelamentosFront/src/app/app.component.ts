import { Component } from '@angular/core';

import { SlimLoadingBarService } from "ng2-slim-loading-bar";

import {NavigationCancel,
Event,
NavigationStart,
NavigationEnd,
NavigationError,
Router
} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ParcelamentosFront';
  constructor(private loadingBar: SlimLoadingBarService, private router: Router)
  {
    this.router.events.subscribe((event: Event) => 
    {
      this.NavigationInterceptor(event);
    });
  }

  private NavigationInterceptor(event: Event): void 
  {
    if(event instanceof NavigationStart)
    {
      this.loadingBar.start();
    }

    if(event instanceof NavigationEnd)
    {
      this.loadingBar.complete();
    }

    if (event instanceof NavigationCancel) 
    {
      this.loadingBar.stop();
    }

    if(event instanceof NavigationError)
    {
      this.loadingBar.stop();
    }
  }
}
