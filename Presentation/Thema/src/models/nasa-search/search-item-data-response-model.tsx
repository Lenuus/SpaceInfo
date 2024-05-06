class SearchItemResponseDataModel {
    public center: string = "";
    public date_created: Date = new Date();
    public description: string = "";
    public keywords: string[] = [];
    public media_type: string = "";
    public nasa_id: string = "";
    public title: string = "";
}

export { SearchItemResponseDataModel }