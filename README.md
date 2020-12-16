# NAC-SA Congregation Music app

## Introduction
As of 2019 the head office have been using Google sheets with a combination of Google drive shares and other online tools to assist Congregation Music Leaders (CML) with the managing of the various aspects of the responsibility.

This application is my attempt at formalising what has been developed by Clarke Schlider and his team over the past few year and facilitate the transfer / access of information.

## Functionality
The following functions are planned for the first release:
### Resources
There are various resources which should be available to a CML, these include (for now)
 * Concordances (for the various publications)
 * Audio and PDF scores of some of the hymns
 * PDF scores of leaflets
 * Hymn schedule for congregational singing (released annually)
 * Public calendar of events (including training initiatives scheduled for the year)
 * Practise planner
 * Festive Divine Service planner (annual planning)

### Structure
* The information in the structure section is *confidential* and should only be available to the CML and leaders.
    * Names and contact details of leaders
    * Names and contact details of musicians (members)
    * Abilities (instruments and voices) of members
* Dashboard: Giving an overall idea of the **health** of the music in the congregation
### Registers
* Hymn registers
* Attendance registers for the various activities:
    * Choir practises
    * Sunday school music practises
    * Orchestra practises etc etc

## Technical
This application is based on the [SAFE Stack](https://safe-stack.github.io/) and was generated using the template.
### Before you start, you need the prerequisites:

* The [.NET Core SDK](https://www.microsoft.com/net/download) 3.1 or higher.
* [npm](https://nodejs.org/en/download/) package manager.
* [Node LTS](https://nodejs.org/en/download/).

### More reading:
#### SAFE Stack Documentation
If you want to know more about the full Azure Stack and all of it's components (including Azure) visit the official [SAFE documentation](https://safe-stack.github.io/docs/).

You will find more documentation about the used F# components at the following places:

* [Saturn](https://saturnframework.org/docs/)
* [Fable](https://fable.io/docs/)
* [Elmish](https://elmish.github.io/elmish/)