import Script from "next/script";
import pageList from "../cms-pages/pageList";

/*
 * generateStaticParams returns an array with all routes that should be
 * pre-rendered in build time.
 * i.e.: [ { path: ["en"] }, { path: ["en", "standard"] } ]
 */

export async function generateStaticParams() {
  const pages = await fetch("https://localhost:5000/routes/get", {
    cache: "no-store",
  }).then((res) => res.json());

  return pages.map((page: any) => ({
    path: splitStringBySlash(page.virtualPath),
  }));
}

async function getData(route: string) {
  const res = await fetch(
    `https://localhost:5000/api/episerver/v3.0/content?contentUrl=${route}&matchExact=true&expand=*`,
    { next: { revalidate: 3600 } }
  );

  if (!res.ok) {
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

export default async function Page({ params }: { params: { path: string[] } }) {
  const { path } = params;
  const url = generateRouteString(path);
  const data = await getData(url);

  if (!data) return <div>There was an error fetching data</div>;
  if (data && data.length === 0) return <div>404 Page not found</div>;

  const model = data[0];

  if (model.contentType?.length) {
    const componentName = model.contentType[1];
    const Page = pageList[componentName];
    return (
      <>
        <Page model={model} />
        {/*
          For OPE to work: 
          <Script src="https://localhost:5000/episerver/cms/latest/clientresources/communicationinjector.js" /> 
        */}
      </>
    );
  }

  return <div>There was an error identifying the page</div>;
}

/*
 * Helpers
 */

const splitStringBySlash = (string: string): string[] =>
  !string ? [] : string.replace(/^\/|\/$/g, "").split("/");

const generateRouteString = (routes: string[]): string =>
  !routes?.length ? "%2F" : `%2F${routes.join("%2F")}`;
