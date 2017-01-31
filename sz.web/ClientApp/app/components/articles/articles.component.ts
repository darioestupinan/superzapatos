import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'articles',
    templateUrl: './articles.component.html'
})
export class ArticlesComponent {
    public articles: Article[];

    constructor(http: Http) {
        http.get('http://localhost:62115/services/articles').subscribe(result => {
            this.articles = result.json().articles as Article[];
        });
    }

    onSelect(article: Article) {
        console.log(article);
    }
}

interface Article {
    id: string;
    name: string;
    description: string;
    price: number;
    totalInShelf: number;
    totalInVault: number;
    storeId: number;
}
