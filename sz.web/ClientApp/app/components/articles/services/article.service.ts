import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Article } from '../models/article.model';
import { Store } from '../models/store.model';


@Injectable()
export class ArticleService {
    private api = 'http://localhost:62115/services/';
    private api_articles = this.api + 'articles/';
    private api_stores = this.api + 'stores/';  
    private articles: Article[];  

    constructor(private _http: Http) {
    }

    getArticles(): Observable<Response> {        
        return this._http.get(this.api_articles);            
    }

    saveArticle(article: Article): Observable<Response> {
        let headers = new Headers({
            'Content-Type': 'application/json', 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let json = JSON.stringify(article);        
        return this._http.post(this.api_articles, json, options);            
    }

    getStores(): Observable<Response> {
        return this._http.get(this.api_stores);
    }  

}