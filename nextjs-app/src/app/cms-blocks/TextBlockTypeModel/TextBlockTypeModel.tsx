import { TextBlockType } from "./TextBlockTypeModelType";
import styles from "./TextBlockTypeModel.module.css";

const TextBlockTypeModel = ({
  model,
  value,
}: {
  model: TextBlockType;
  value: any;
}) => {
  if (!model) return null;
  return (
    <div className={`${styles.container} ${styles[value.displayOption]}`}>
      <h2>{model.heading.value}</h2>
      <div dangerouslySetInnerHTML={{ __html: model.textBody.value }}></div>
    </div>
  );
};

export default TextBlockTypeModel;
