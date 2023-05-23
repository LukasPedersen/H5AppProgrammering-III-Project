<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="https://github.com/LukasPedersen/H5AppProgrammering-III-Project/assets/61869988/4e13c525-68a4-40d1-9a40-cee90f296759" alt="Logo" width="220" height="220">
  </a>

  <h3 align="center">Chill Watcher README!</h3>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
Chill Watcher er en App som på nuværende tidspunkt kun er tilgængelig på Android.

Der findes nogle Apps der minder om Chill Watcher men her er nogle gode grunde til hvorfor du skal bruge Chill Watcher:
* Du kan monitorere temperature og fugtighed LIVE! på Appen.
* Det er muligt at indstille en ønsked temperature og fugtighed med kun få click!
* Du kan åbne dine vinduer via Appen!
* Gå tilbare og kigge på hvor varmt det har været.
* Hvis du ikke har internet til nettet bliver alle ændringer updateret så snart til tlf får forbindelse igen!

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With
___
|  MAUI  |  C#  |  MQTT  |  Minimal API  |  InfluxDB  |
|---|---|---|---|---|
|  <img src="https://github.com/LukasPedersen/H5AppProgrammering-III-Project/assets/61869988/bdaa047a-7892-4593-9627-39e5e18ecbe9" alt="Logo" width="120" height="120">  |  <img src="https://github.com/LukasPedersen/H5AppProgrammering-III-Project/assets/61869988/b2da569a-06aa-4c5b-95c0-8259c661d7f6" alt="Logo" width="120" height="120">  |  <img src="https://github.com/LukasPedersen/H5AppProgrammering-III-Project/assets/61869988/5b74a28d-3711-42c7-b695-46c6ab36d9d3" alt="Logo" width="155" height="155">| <img src="https://github.com/LukasPedersen/H5AppProgrammering-III-Project/assets/61869988/a6e03e24-9096-4dab-b82e-324a5183ddc2" alt="Logo" width="120" height="120">  |  <img src="https://github.com/LukasPedersen/H5AppProgrammering-III-Project/assets/61869988/a5a46e98-d1fd-486c-9189-0c35e66b3537" alt="Logo" width="120" height="120">  |
___
<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Topics -->
## Topics
---
| Topic | Type | Body | Description |
|---|---|---|---|
| devices/```deviceId```/messages/devicebound | Subscribe | ```{ "LED": "ON" }``` | Tell device to turn LED ON or OFF |
| devices/```deviceId```/messages/devicebound | Subscribe | ```{ "Servo": 120 }``` | Tell device to turn Servo to x degrees |
| devices/```deviceId```/messages/telemetry | Publish | ```{ "temperature": 25.5, "humidity": 68.2 }``` | Send telemetry to broker |
---
<!-- Api Endpoints -->
## Api Endpoints
| Endpoint | Type |
|---|---|
| /setLED | POST |
| /setServo | POST |
| /createTelemetry | POST |
| /getTelemetry | GET |
<!-- GETTING STARTED -->
## Getting Started

1. Go to Google play store
2. Search for Chill Watcher
3. Install Chill Watcher
4. Set up sensors

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  Install-Package CommunityToolkit.Mvvm -ProjectName ChillWathcerApp
  ```
  ```sh
  Install-Package LiveChartsCore.SkiaSharpView.Maui -ProjectName ChillWathcerApp
  ```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Get a free API Key at https://eu-central-1-1.aws.cloud2.influxdata.com/orgs/b8fb8b6306ae7726/load-data/tokens
2. Clone the repo
   ```sh
   git clone https://github.com/LukasPedersen/H5AppProgrammering-III-Project.git
   ```
3. Install NPM packages
  ```sh
  Install-Package CommunityToolkit.Mvvm -ProjectName ChillWathcerApp
  ```
  ```sh
  Install-Package LiveChartsCore.SkiaSharpView.Maui -ProjectName ChillWathcerApp
  ```
4. Enter your API in `secrets.json`
   ```js
   const API_KEY = 'APIKey';
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [ ] Kan vise aktuel (seneste måling) af temperatur og humidity og de målte tidspunkter i lokal tid
- [ ] Kan vise en graf over målingerne, hvor man kan vælge mellem seneste time, dag og uge.
- [ ] Der skal være en knap, der via MQTT kan aktivere en servo (og simulere at man åbner et vindue eller tænder for ventilationen).
- [x] App'en skal opbygges med MVVM design pattern og Dependency Injection.
- [ ] Kan vise seneste data, hvis nettet afbrydes. 
- [ ] Er robust overfor ustabil netforbindelse.
- [x] Projektet afleveres i Github med en god Readme-fil og præsenteres for klassen. Readme-filen markerer også hvilke mål, der er nået.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Architecture -->
## Architecture

![image](https://github.com/LukasPedersen/H5AppProgrammering-III-Project/assets/61869988/5ff83101-02d8-4e98-ad66-3a93bdbd1cea)

<!-- CONTACT -->
## Contact

Lukas Nørskov Pedersen - luka0591@elevcampus.dk

Project Link: [LukasPedersen/H5AppProgrammering-III-Project](https://github.com/LukasPedersen/H5AppProgrammering-III-Project)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

Use this space to list resources you find helpful and would like to give credit to. I've included a few of my favorites to kick things off!

* [Choose an Open Source License](https://choosealicense.com)
* [GitHub Emoji Cheat Sheet](https://www.webpagefx.com/tools/emoji-cheat-sheet)
* [Malven's Flexbox Cheatsheet](https://flexbox.malven.co/)
* [Malven's Grid Cheatsheet](https://grid.malven.co/)
* [Img Shields](https://shields.io)
* [GitHub Pages](https://pages.github.com)
* [Font Awesome](https://fontawesome.com)
* [React Icons](https://react-icons.github.io/react-icons/search)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[Maui.js]: 
[Maui-url]:
[Next.js]: https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white
[Next-url]: https://nextjs.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[Vue.js]: https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vuedotjs&logoColor=4FC08D
[Vue-url]: https://vuejs.org/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[Laravel.com]: https://img.shields.io/badge/Laravel-FF2D20?style=for-the-badge&logo=laravel&logoColor=white
[Laravel-url]: https://laravel.com
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com 
