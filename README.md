# XamarinAppStartupTime
Xamarin Forms app that demonstrates how to measure total app startup time in xamarin android

It uses ContentProvider written in Java to measure start time as early as possible, even before loading mono runtime. Why ContentProvider?
Well, because ContentProvider starts even before app process is started, so this method guarantees that we measure whole time it takes to setup application, including loading mono runtime.

Some screenshots, for some reason I'm getting higher startup time with app built on Visual Studio 2019.

| VS2019 | VS2017 |
| --- | --- |
| ![Screenshot_20190406-225215](https://user-images.githubusercontent.com/3065454/55675304-ec200f80-58c0-11e9-8161-22f8fb862913.jpg) | ![Screenshot_20190406-225742](https://user-images.githubusercontent.com/3065454/55675307-ef1b0000-58c0-11e9-82be-b742dabc076d.jpg) |





