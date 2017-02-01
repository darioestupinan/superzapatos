import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Article } from './models/article.model';
import { Store } from './models/store.model';
import { ArticleService }  from './services/article.service';

@Component({
    selector: 'articles',
    templateUrl: './articles.component.html', 
    providers : [ ArticleService ]
})

export class ArticlesComponent {
    public articles: Article[];
    
    constructor(private _service : ArticleService) {
        this._service.getArticles().subscribe(result => {
            this.articles = this.convertToArticle(result.json());
        });
    }

    convertToArticle(res) {
        let body = res.articles;
        let result: Article[] = [];
        if (body instanceof Array) {
            for (let i = 0; i < body.length; i++) {
                let article: Article = {
                    id : body[i].id || 0,
                    name: body[i].name || "",
                    description: body[i].description || "",
                    price: body[i].price,
                    total_in_shelf: body[i].total_in_shelf || 0,
                    total_in_vault: body[i].total_in_vault || 0,
                    store_name: body[i].store_name || "",
                    store_id : 0
                };
                result.push(article);
            }
        }
        return result;
    }

    onSelect(article: Article) {
        console.log(article);
    }

    onArticleSelect(store: Store) {
        console.log(store);
    }
}
