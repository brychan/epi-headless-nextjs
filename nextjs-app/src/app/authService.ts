import { Issuer, TokenSet } from "openid-client";

const authenticate = async () => {
  const issuer = await Issuer.discover("https://localhost:5000").catch(
    (error) => console.log("error", error)
  );

  if (!issuer) {
    return;
  }

  const client = new issuer.Client({
    client_id: "cli",
    client_secret: "cli",
  });

  return await client
    .grant({
      grant_type: "client_credentials",
      scope: "epi_content_delivery",
    })
    .catch((error) => console.log("error", error));
};

export default authenticate;