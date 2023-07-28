import styles from "./HeroElement.module.css";

interface HeroElementProps {
  heading: string;
  backgroundImage?: string;
}

const HeroElement = ({ heading, backgroundImage }: HeroElementProps) => {
  return (
    // For OPE use i.e:  data-epi-edit={"HeroHeading"}
    //                   data-epi-edit={"HeroBackgroundImage"}
    <div
      className={styles.container}
      style={{
        background: backgroundImage
          ? `url("${backgroundImage}")`
          : "lightseagreen",
      }}
    >
      <h1 className={styles.heading}>{heading}</h1>
    </div>
  );
};

export default HeroElement;
