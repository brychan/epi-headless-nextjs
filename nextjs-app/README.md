# Next.js Episerver Headless Content Delivery API Project
This project is a Next.js application that utilizes the Episerver Headless Content Delivery API to render CMS pages and blocks. The primary goal is to leverage NextJs Static Site Generation, and create static HTML/CSS/JS for most of the pages at build time and provide seamless server-side rendering for new or dynamic routes.

## How to run
In the directory run:

```bash
$ npm install
$ npm run build
$ npm run start
````


## Directory
/app
	/[[...page]]
		- Catches ALL pages and fetches data from Content Delivery API.
		- Optimizely backend resolves routing, including language.
		
	/cms-pages
		- Store each Model in a folder with CSS module, TS types, etc.
	
	/cms-blocks
		- Store each Model in a folder with CSS module, TS types, etc.
	
	/components
		- Store reusable UI components

### /cms-pages (Pages Content Type) - i.e. StandardPageTypeModel
- This page type represents standard CMS pages.
- It is a server-side component that compiles into HTML.
- Receives the full CD API response as the Model.
- Displays data from the Model.
- Utilizes Server Components CMS-Blocks for property blocks.
- Uses Server Component Content Area for content areas.
- Utilizes reusable isolated Server Components if synchronous.
- Uses reusable isolated Client Components if asynchronous.

### /cms-blocks (Blocks Content Type) - i.e. TextBlockTypeModel
- This block type represents text blocks used within CMS pages.
- It is a server-side component that compiles into HTML.
- Receives the Model from the Page.
- Displays data from the Model.
- Utilizes Server Components CMS-Blocks for property blocks.
- Uses Server Component Content Area for content areas.
- Utilizes reusable isolated Server Components if synchronous.
- Uses reusable isolated Client Components if asynchronous.

## During Build
1. Next.js generates all routes like route/page.tsx into static HTML/CSS/JS during the build process.
2. For dynamic/catch-all routes (e.g., "[[...page]]"), generateStaticPath() is called to retrieve an array of all routes in the site from a custom endpoint in the Optimizely CMS server.
3. For each route in the array, the corresponding "[[...page]]/page.tsx" is generated into HTML/CSS/JS, with the path received as a Prop.
4. The "[[...page]]/page.tsx" component retrieves the page data from the Content Delivery API by passing the route.
5. The "[[...page]]/page.tsx" component compiles the data with any Blocks or Content Area into static HTML/CSS/JS.
6. Static files are automatically cached and ready to be served when the server starts running.

## Requests at Runtime
1. Next.js checks if the requested page is static and stored in the cache.
2. If it is, then it serves the page. If it needs to be revalidated, it serves the "old" page and generates a new one in the background.
3. If the page is not static, Next.js runs the "[[...page]]/page.tsx" component with the path received as a Prop.
4. The "[[...page]]/page.tsx" component retrieves the page data from the Content Delivery API by passing the route.
5. The "[[...page]]/page.tsx" component compiles the data with any Blocks or Content Area into static HTML/JS.
6. Static files are automatically served and cached.

## Fetching Data from an Endpoint
If the page needs to retrieve data from any endpoint (e.g. "/components/CoinDeskData"):

1. Isolate the section of the page that needs the data.
2. Create a Client Component that fetches the data asynchronously.
3. Surround it in a Suspense boundary to display a loading state until the data is fetched.
