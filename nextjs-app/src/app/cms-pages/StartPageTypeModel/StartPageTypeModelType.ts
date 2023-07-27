import {
  ContentAreaType,
  PageContentType,
  PropertyContent,
  PropertyContentImage,
} from "../../../types";

export interface StartPageType extends PageContentType {
  siteName: PropertyContent;
  heroHeading: PropertyContent;
  heroBackgroundImage: PropertyContentImage;
  contentBlocks: ContentAreaType;
}
