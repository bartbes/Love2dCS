
![logo](https://github.com/endlesstravel/Love2dCS/raw/master/img/logo.png "logo") 

Love2dCS - C# Wrapper for LÖVE
---
Love2dCS is a C# Wrapper for [LÖVE game engine](https://love2d.org/), it can be used your C# based Application. 

Love2dCS was designed to be as close as possible to the original LÖVE API, as such the documentation provided from LÖVE largely covers usage of Love2dCS. There is a slight difference between Love2dCS and LÖVE where is :

* The `love.math` module in love is replaced by `Love.Mathf` in Love2dCS
* The `love.thread` module in love is not ready to supply, you can use threads in C # instead.
* Most index begin from 1 at LÖVE. However, index will begin from 0 at Love2dCS
* *More in development ... *

Love2dCS currently based on [LÖVE 0.10.2](https://love2d.org/wiki/0.10.2)

Love2dCS currently supports Windows x86. The next step will be to support windows x64. Linux and OSX temporarily was not supported.

Physics module temporarily not support.

Feature
---

* Easy to install
* Easy to use

Setup & Getting Started
---

1. Available on NuGet: https://www.nuget.org/packages/Love2dCS/

2. And **REMEBER** enable native code debugging in VS : `Configuration Properties/Debugging/Enable native code debugging`

Please read [README-getting-started.md](README-getting-started.md) for more detail.

Examples
---

Drawing text
``` C#
using Love;
namespace Example
{
    class Program : Scene
    {
        public override void Draw()
        {
            Graphics.Print("Hello World!", 400, 300);
        }

        static void Main(string[] args)
        {
            Boot.Run(new Program());
        }
    }
}
```
[More examples](README-getting-started.md#more-examples)

Next to development
---
 - [ ] Add support for Physics 
 - [ ] Improve the document
 - [ ] Add support for win-x64 platform

Documentation
---
*In development ...*

Temporarily please reference [love wiki](https://love2d.org/wiki/love)

Distribute
---
*In development ...*

Develpoment
---

1. clone repository `git clone https://github.com/endlesstravel/Love2dCS`

2. Build C part :

* Follow the instructions at the [megasource](https://bitbucket.org/rude/megasource) repository page to build LÖVE 0.10.1+.
* Add files `c_api_src/wrap_love_dll.cpp ` and `c_api_src/wrap_love_dll.h` to your LÖVE project in `liblove`.

![liblove-src](https://github.com/endlesstravel/Love2dCS/raw/master/img/006-liblove-src.png "liblove-src")

3. Build C# part :

* Create a C# library project
* Add all `cshapr_src/*.cs` to your C# library project.
* **REMEBER** enable native code debugging in VS : `Configuration Properties/Debugging/Enable native code debugging`

*In development ...*
