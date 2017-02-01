import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Response } from '@angular/http';
import { Http, Headers } from '@angular/http';
import { Article } from '../models/article.model';
import { Store } from '../models/store.model';

@Injectable()
export class StoreService {
    private api = 'http://localhost:62115/services/';
    private api_stores = this.api + 'stores/';
    private api_articles = this.api + 'articles/';  
    private articles: Article[];  

    constructor(private _http: Http) {
    }

    getStores(): Observable<Response> {        
        return this._http.get(this.api_stores);        
    }

    getProductsByStore(store: Store): Observable<Response> {
        return this._http.get(this.api_articles + "stores/" + store.id);
    }

    saveArticle(article: Article) : Observable<Response> {
        let json = JSON.stringify(article);
        return this._http.post(this.api_stores, json);
        
    }
}