import { ContentAreaType, PageContentType, PropertyContent, PropertyContentReference } from "../../../types";

export interface StandardPageType extends PageContentType {
    heading: PropertyContent;
    link: PropertyContentReference;
    textBody: PropertyContent;
    contentBlocks: ContentAreaType;
}
