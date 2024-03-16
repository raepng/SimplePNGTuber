# SimplePNGTuber
This is yet another PNGTuber software. Its purpose is to be just a small application but with some interesting features that other simple PNGTuber softwares usually dont have.
It has an http server that lets you change the current PNGTuber model as well as the models expressions and accessories.
Note that it works only with GET requests since it is supposed to be really easily usable in combination with [Streamer.bot](https://streamer.bot/)'s Fetch URL function (which only sends GET Requests).
## The PNGTuber model
The PNGTuber model file is a zip file containing the different expressions and accessories (with neutral as the basic expression) as png files. These files need to be named accordingly. Expression files start with `exp_`
followed by the name of the expression for example `neutral` which is in term followed by another underscore and then a numer from 0 to 3:
```
exp_neutral_0.png - not speaking, not blinking
exp_neutral_1.png - speaking, not blinking
exp_neutral_2.png - not speaking, blinking
exp_neutral_3.png - speaking, blinking
```
Accessory files are prefixed with `acc_`:
```
acc_flowers.png
```
---
Please note that this software is just a fun project. There are plans for adding a "Create Model"-Dialogue that lets you easily select your images for the expressions and accessories you want to have.
It is also planned to add some audio filters to the microphone capture to improve voice capture and reduce the picking up of background noises.
