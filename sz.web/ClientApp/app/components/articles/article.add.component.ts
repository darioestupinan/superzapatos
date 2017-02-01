import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Article } from './models/article.model';
import { Store } from './models/store.model';
import { ArticleService }  from './services/article.service';
import { FormsModule }   from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@Component({
    selector: 'articles.add',
    templateUrl: './article.add.component.html',
    providers: [ArticleService]           
})
export class ArticleAddComponent{
    public article: Article;
    public stores: Store[];
    public selecteStore: Store;
    public newArticle: Article = new Article();
    public submitted: boolean = false;

    constructor(private _service : ArticleService) {
        this._service.getStores().subscribe(result => {
            this.stores = result.json().stores as Store[]
            this.selecteStore = this.stores[0];
        });    
    }    

    onSubmit() {
        this.submitted = true;
        this._service.saveArticle(this.newArticle).subscribe(result => {
            this.newArticle = result.json().article;
        });
        console.log(this.newArticle);
    }

    createNewArticle() {
        this.newArticle = new Article();
    }   
}


