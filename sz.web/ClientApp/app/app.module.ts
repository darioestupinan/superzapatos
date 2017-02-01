import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ArticlesComponent } from './components/articles/articles.component';
import { StoresComponent } from './components/stores/stores.component';
import { ArticleAddComponent } from './components/articles/article.add.component';


@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ArticlesComponent,
        StoresComponent,
        ArticleAddComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.        
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },            
            { path: 'articles', component: ArticlesComponent },
            { path: 'articles.add', component: ArticleAddComponent },
            { path: 'stores', component: StoresComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
