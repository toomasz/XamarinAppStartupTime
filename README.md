# XamarinAppStartupTime
Xamarin Forms app that demonstrates how to measure total app startup time in xamarin android

It uses ContentProvider written in Java to measure start time as early as possible, even before loading mono runtime. Why ContentProvider?
Well, because ContentProvider starts even before app process is started, so this method guarantees that we measure whole time it takes to setup application, including loading mono runtime.

Some screenshots, for some reason I'm getting higher startup time with app built on Visual Studio 2019.

| VS2019 | VS2017 |
| --- | --- |
| ![Screenshot_20190411-195519](https://user-images.githubusercontent.com/3065454/55980785-81425000-5c95-11e9-9763-f27bc4d0993f.jpg) | !![Screenshot_20190411-200312](https://user-images.githubusercontent.com/3065454/55980787-81dae680-5c95-11e9-9294-7b51b737c0f6.jpg) |





