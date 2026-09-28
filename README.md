# Database

```plantuml
@startuml

object Track {
<u>Id
Title
Artist
Duration
Rating
}

object Album {
<u>Id
Name
CreationDate
Visibility
<i>#Creator
}

object User {
<u>Id
Name
Role
}

object Contains {
<u>Id
<u><i>#TrackId
<u><i>#AlbumId
CustomTitle
}

object Friend{
<u><i>#User1Id
<u><i>#User2Id
}

Contains-- Album
Contains-- Track
User -- Album
User -- Friend
User -- Friend


@enduml
```

# UseCase

```plantuml
@startuml

left to right direction

actor Visitor
actor User
actor Admin

User--|> Visitor
Admin--|> User

rectangle "Genshin OST API" {

    usecase "Open public album" as UC1
    usecase "Open track" as UC2

    usecase "Create album" as UC3
    usecase "Edit album" as UC4
    usecase "Delete album" as UC5

    usecase "Add track to album" as UC6
    usecase "Remove track from album" as UC7

    usecase "Add friend" as UC8
    usecase "Remove friend" as UC9

    usecase "Manage official albums" as UC10
    usecase "Manage tracks" as UC11
}

Visitor --> UC1
Visitor --> UC2

User--> UC3
User--> UC4
User--> UC5
User--> UC6
User--> UC7
User--> UC8
User--> UC9

Admin--> UC10
Admin--> UC11

@enduml
```

## Details :

### Album Visibility :

- Official (admin only) : Everyone can open the album
- Public : Logged users can open the album
- Private : Friends can open the album
- Closed : Only the owner can open the album
