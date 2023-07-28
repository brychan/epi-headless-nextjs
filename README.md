# Optimizely CMS 12 Headless + NextJs
This project is a decoupled Next.js application that leverages the Optimizely Headless Content Delivery API to create a high-performance and scalable website. It utilizes static site generation (SSG) for all pages published at build time and generates static HTML/CSS/JS files for improved performance. New routes are rendered at runtime and its static files cached for subsequent requests.

## Project Features
- Utilizes Episerver Headless Content Delivery API for CMS pages and blocks.
- All routing is automatically handled by the CMS, including multiple languages.
- Implements Server Components for rendering pages and blocks as static HTML.
- Content Areas are resolved automatically.
- Employs reusable isolated components for synchronous and asynchronous rendering.
- Can use CMS DisplayOptions to determine the layouts.

## To Do's
- ~~(CMS) Add filtering of properties.~~
- ~~(CMS) Add filtering of private pages.~~
- (NextJs) Syncronize Typescript types with CMS models.
- (NextJs + CMS) Add On-page editing to the solution.

## Getting Started
- Clone this repository.
- Install project dependencies in "/nextjs-app" using npm install.
- Set up the necessary configuration for accessing the Episerver Headless Content Delivery API.
- Start the development server using npm run dev.
- Build the project for production using npm run build.

## Additional Information
For more documentation on the project, refer to the respective README files in the /nextjs-app and /cms-server directories.
