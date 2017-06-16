import { Component, Injectable } from "@angular/core";
import { CookieService, CookieOptionsArgs } from 'angular2-cookie/services';

@Injectable()

class CookieArgs implements CookieOptionsArgs {
    expires?: string | Date;
}

export class CookieWrapperService {

    private _cookie: CookieService;

    constructor() {
        this._cookie = new CookieService();
    }

    // TODO: change type to profile objects
    public put(cookieName: string, data: string): void {
        let args = new CookieArgs();
        args.expires = new Date(2030, 12);
        this._cookie.put(cookieName, data, args);
    }

    public get(cookieName: string): string {
        return this._cookie.get(cookieName);
    }
}