import { TextAndImageBlockType } from "./TextAndImageBlockTypeModelType";
import styles from "./TextAndImageBlockTypeModel.module.css";
import { ContentLinkWithId } from "@/types";

const TextAndImageBlockTypeModel = ({
  model,
  value,
}: {
  model: TextAndImageBlockType;
  value: any;
}) => {
  if (!model) return null;
  return (
    //For OPE use data - epi - content - id={ (model.contentLink as ContentLinkWithId).id }
    <div
      className={`${styles.container} ${styles[value.displayOption]}`}
    >
      <div
        className={styles.heading}
        style={{
          background: `url("${model.blockImage?.value?.url}")`,
        }}
      >
        <h2>{model.heading.value}</h2>
      </div>
      <div
        className={styles.body}
        dangerouslySetInnerHTML={{ __html: model.textBody.value }}
      ></div>
    </div>
  );
};

export default TextAndImageBlockTypeModel;
