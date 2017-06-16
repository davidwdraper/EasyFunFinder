export class User {
    public Id: number;
    public CookieId: string;
    public UniqueId: string;
    public FirstName: string;
    public LastName: string;
    public Email: string;
    public IsBusinessUser: boolean;
    public LastLoginDateTime: Date;

    public ImageIds: string[];
    public UserProfileIds: number[];
    public EntertainerIds: number[];
    public EventIds: number[];
    public RoleIds: number[];
}
