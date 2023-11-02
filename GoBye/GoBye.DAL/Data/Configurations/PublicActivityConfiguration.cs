using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class PublicActivityConfiguration : IEntityTypeConfiguration<PublicActivity>
    {
        public void Configure(EntityTypeBuilder<PublicActivity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.ImageURL)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.Description)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder.HasOne(x => x.Destination)
                .WithMany(x => x.PublicActivities)
                .HasForeignKey(x => x.DestinationID)
                .IsRequired();

            builder.ToTable("PublicActivities");

            
            builder.HasData(new List<PublicActivity>
            {

                #region Red Sea
                new PublicActivity 
                {
                    Id=1,
                    Title="Sharm Al-Nagaa Beach",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-01.jpg",
                    Description="Naga is located 40 km from Hurghada, and is a must visit place." +
                    " The calmness of its waves and the serenity of its sky make this spot the most suitable place for recreation and relaxation." +
                    " You will have a very beautiful day in the enchanting nature; never miss a chance to do diving," +
                    " or snorkeling in its water rich in the beautiful coral reefs that are so close to the beach.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=2,
                    Title="Mahmya Beach in Giftun Island",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-02.jpg",
                    Description="Giftun Island is located 10 km away from Hurghada." +
                    " They don't exaggerate when some say that it's Egypt's Maldives, as nature in its beach is like no other." +
                    " The scenery there really fascinates everyone who visits it. The white sands," +
                    " the clear blue sea that makes you see the undersea; will make your cruise the most enjoyable experience ever.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=3,
                    Title="Hurghada Marina",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-03.jpg",
                    Description="Hurghada Marina is located next to Sayadeen Village in Sekala Area and is considered and is an integrated entertainment area." +
                    " This place is suitable to spend beautiful nights with the family," +
                    " and to enjoy the beautiful view of the charming yachts, the marina is considered the largest yacht marina in Hurghada." +
                    " So whether you will go in the evening to enjoy the restaurants, and the cafes," +
                    " or you will go in the morning for diving and fishing, you will definitely have a great time.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=4,
                    Title="Makadi Bay",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-02.jpg",
                    Description="Makadi Bay is located between Safaga and Hurghada," +
                    " 35 km south of Hurghada. It is characterized by the presence of approximately 15 resorts and " +
                    "hotels overlooking the red sea through the beautiful tourist Promenade. You can go for a walk or stroll" +
                    " through the exquisite nature and refreshing atmosphere.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=5,
                    Title="Mini Egypt",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/05/miniegypt.jpg",
                    Description="You can see the most beautiful and most famous landmarks of Egypt in a miniature grouped in one place." +
                    " The reduction ratio of the models is 1:25, between the Library of Alexandria," +
                    " the Cairo Tower, the Pyramids of Giza, Tahrir Square, Maspero and the Temple of Abu Simbel," +
                    " and others. As if you are taking a quick tour of the cities and landmarks of Egypt." +
                    " Some still do not know about the monuments and entertainment in the coastal cities.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=6,
                    Title="Makadi Water World",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/05/waterworld.jpg",
                    Description="Makadi Water World, which is located just outside Hurghada, " +
                    "is one of the largest amusement parks in Egypt. This place is very suitable for spending a day with family full of fun." +
                    " You can enjoy swimming pools and play in the amusement parks and water games," +
                    " which number up to fifty games and are suitable for all ages." +
                    " You will also find what you want from restaurants and cafes.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=7,
                    Title="Dolphin World",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/05/dolphinworld.jpg",
                    Description="It's nice to see a fun, unusual show, accompanied by dance music and amazing acrobatics," +
                    " but imagine that this show features a group of dolphins? It will definitely be more beautiful and fun." +
                    " Such is the case at Dolphin World, the most popular place for entertaining dolphin shows." +
                    " She presents her talents in front of the audience who are happy with her." +
                    " The offers are amazing for both kids and adults.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=8,
                    Title="Cruises and Water Sports",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/hurghada-02.jpg",
                    Description="If you want to spend a special day, you should go on a cruise inside the beautiful waters of Makadi." +
                    " You can also practice different sports and water activities." +
                    " Do not miss the experience of diving there and exploring the enchanting nature under the water's surface.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=9,
                    Title="Mangrove tree",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/05/Mangrof-tree.jpg",
                    Description="One of the most famous charming attractions and must-see places is Qalaan Beach," +
                    " where the mangrove tree is located. This tree is considered one of the most beautiful and oldest trees," +
                    " as it reaches a thousand years old and grows beautifully in salt water." +
                    " Your visit will definitely be amazing and unforgettable." +
                    "    Qalaan Beach is characterized by the presence of different types of birds and forms of migratory birds.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=10,
                    Title="Hankorab Beach - Sharm El Luli",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/05/sharm-el-loly.jpg",
                    Description="Surely you have heard about dolphins in Marsa Alam and wished to swim alongside them." +
                    " You can do this and more at Hankorab Beach, known as “Sharm El Louli”," +
                    " which is considered one of the most beautiful beaches in the world. " +
                    "The beach is located 55 km from the city, within the Bedouin village of Abu Ghosoun," +
                    " and the beach attracts many tourists every year.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=11,
                    Title="Marsa Mubarak",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/05/Marsa-Mubarek.jpg",
                    Description="It is not only dolphins that you can swim alongside in Marsa Alam," +
                    " but you can also sail with turtles in the waters of Marsa Mubarak." +
                    " Marsa Mubarak Bay is located 7 km from Marsa Alam International Airport." +
                    " It is characterized by its charming aquatic nature, which contains the most beautiful creatures.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=12,
                    Title="Porto Ghalib",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/05/Porto-ghaleb.jpg",
                    Description="Night and night in Marsa Alam also has its own magic; After a long day of various activities," +
                    " you can head out in Porto Ghalib. There you will find everything you want from restaurants" +
                    " and cafes and enjoy the beautiful sea view.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=13,
                    Title="Walkway in Porto Sokhna",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-01.jpg",
                    Description="You can find in it what you want from different chains of restaurants and cafes." +
                    " It is characterized by the presence of the walkway, where you will find various markets," +
                    " shows and entertaining songs, in addition to children's competitions." +
                    " The most important thing that distinguishes Porto Sokhna is also the cable car trips," +
                    " which are the first of their kind in Egypt. It covers a distance of about a kilometer, " +
                    "during which you can fly to the top of the mountain in Ain Sukhna, then you will see an unparalleled view of splendor and beauty.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=14,
                    Title="Cruises",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-02.jpg",
                    Description="If you want to spend a beautiful day with friends and family," +
                    " you should rent a yacht and take a cruise inside the waters of the Red Sea." +
                    " There are boats that can accommodate up to 30 people, " +
                    "all equipped with everything you will need for food and water sports." +
                    " You will spend a fun day between fishing and taking the most beautiful pictures." +
                    " You can also sail to the best places for snorkeling and swimming with dolphins.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=15,
                    Title="Cancun and Porto South Beach Resorts",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-03.jpg",
                    Description="If you are going to spend more than a day or even one day," +
                    " in the resorts of Cancun and South Beach you will find what you desire in terms of beautiful beach," +
                    " recreation and comfort. You will be able to enjoy the swimming pools and relax on the sea with animation shows and fun parties.",
                    DestinationID=2,
                },

                new PublicActivity
                {
                    Id=16,
                    Title="Mountains and Water Springs",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/sokhna-04.jpg",
                    Description="One of the most important natural landmarks in Ain Sukhna is the Galala Mountain Range." +
                    " Its height is 1200 meters and it is located south of Ain Sokhna." +
                    " His great position is due to the fact that many believe that Moses passed over it to the Red Sea." +
                    " Among the natural attractions are the sulfur eyes," +
                    " which are famous for their role in healing many skin diseases and attract many tourists for treatment.",
                    DestinationID=2,
                },
                #endregion

                #region South Sinai
                new PublicActivity
                {
                    Id=17,
                    Title="Ras Muhammed National park",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-01.jpg",
                    Description="If you want to see beautiful nature like no other and charming water views, " +
                    "Ras Muhammed National park is the perfect place for you. Diving in this national park is a unique experience you should never miss." +
                    " The underwater view is a real pleasure that takes you to another world where you find" +
                    " yourself in the midst of colorful fish and coral reefs and where you see strange creatures and marine " +
                    "fossils from thousands of years.",
                    DestinationID=3,
                },

                new PublicActivity
                {
                    Id=18,
                    Title="Nabq Protected area",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-02.jpg",
                    Description="Nabq protected area is located between Sharm El Sheikh and Dahab," +
                    " about 35 km from Sharm El Sheikh. This protected area is characterized by its mountain," +
                    " desert and marine nature. Where you can find the beauty of the land and the sweetness of the land together." +
                    " There you can see the most beautiful wildlife of reptiles and rodents," +
                    " Also there are different types of animals and birds." +
                    " Also you can enjoy the experience of watching beautiful marine organisms and rare fish." +
                    " In this protected area you spend a special time between camping and diving.",
                    DestinationID=3,
                },

                new PublicActivity
                {
                    Id=19,
                    Title="Naama Bay",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-03.jpg",
                    Description="Naama Bay is considered the main destination for outings and excursions." +
                    " It has made a special character for Sharm El Sheikh nightlife." +
                    " You can walk in its streets or sit in the beautiful cafes that is full of life." +
                    " In Naama Bay you can find what you want from restaurants and cafes that extend along" +
                    " the Gulf and offer the most enjoyable offers and evenings." +
                    " You will also find excellent shops for shopping with good prices and perfect goods.",
                    DestinationID=3,
                },

                new PublicActivity
                {
                    Id=20,
                    Title="Mount St. Catherine",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Sharm-04.jpg",
                    Description="If you want an unforgettable experience among the tall mountains," +
                    " you have to climb Mount St. Catherine. The journey starts from the early mornings and lasts all day." +
                    " You can climb halfway on a camel, and the other half on your foot as the road has stairs." +
                    " The view of the sunset over the clouds is truly enchanting and worth the adventure." +
                    " You can camp and wake up to watch the sunrise as well.",
                    DestinationID=3,
                },

                new PublicActivity
                {
                    Id=21,
                    Title="Washwashi Valley",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-01.jpg",
                    Description="One of the most beautiful and amazing places is Wadi Al-Wushwashi, which is still unknown to many." +
                    " Wadi Al-Washwashi is located in Nuweiba and is distinguished by combining enjoying the mountainous" +
                    " nature and the beauty of the water together. The journey begins with climbing and hiking " +
                    "the mountains until you reach the green lake. That spot, which was formed by the gathering of torrential water in the winter," +
                    " was embraced by the turquoise and granite mountains in a charming landscape. Only when you see this scene," +
                    " you can only jump and throw yourself in that lake to enjoy its warm water.",
                    DestinationID=3,
                },

                new PublicActivity
                {
                    Id=22,
                    Title="Blue Hole",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-02.jpg",
                    Description="Adventure lovers and those who wish to see unparalleled beauty in the depths of the sea never" +
                    " miss the opportunity to dive in the Blue Hole. It is a patch of water in the Red Sea that" +
                    " reaches a depth of 130 meters. The Blue Hole is one of the most amazing diving places in the world" +
                    " and attracts many tourists every year; It contains colors of coral reefs and marine creatures that you have to enjoy seeing," +
                    " whether through diving or snorkeling. Equipment can be rented on the beach." +
                    " You can also have a unique Bedouin food while relaxing in front of the beautiful sea scenery.",
                    DestinationID=3,
                },

                new PublicActivity
                {
                    Id=23,
                    Title="Abu Galum",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-03.jpg",
                    Description="The charming sands of Abu Galum Beach and the purity and beauty of the water" +
                    " make it the best place to spend a quiet day amidst the picturesque nature." +
                    " The name Abu Galumis due to the presence of the Qalum plant," +
                    " whose name was later changed to Galum. The beach is also characterized by different types of birds and exotic plants;" +
                    " It includes 165 species of ordinary plants and 44 species that you can only find in this region.",
                    DestinationID=3,
                },

                new PublicActivity
                {
                    Id=24,
                    Title="Walkway",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/Dahab-04.jpg",
                    Description="If you want to spend the evening in a more lively place," +
                    " you should head to the tourist walkway, where there are cafes and restaurants," +
                    " including some that offer special musical performances that you will enjoy a lot." +
                    " You can also shop in bazaars and stores and buy clothes and hand-made products at reasonable prices.",
                    DestinationID=3,
                },
                #endregion

                #region Alexandria
                new PublicActivity
                {
                    Id=25,
                    Title="Citadel of Qaitbay",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-01.jpg",
                    Description="Today, the Qaitbay Citadel is different from any other archaeological site." +
                    " Where you can learn about the greatness of history and the beauty of the architecture in the construction of that castle and its forts." +
                    " You can also enjoy the view of the sea that surrounds it from three sides." +
                    " The castle is also beautiful from the outside, " +
                    "where you can wander around the castle's corniche and sit in the various cafes.",
                    DestinationID=4,
                },

                new PublicActivity
                {
                    Id=26,
                    Title="Library of Alexandria",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-02.jpg",
                    Description="Of course, you should never miss the opportunity to visit the Bibliotheca Alexandrina," +
                    " which houses about 8 million books and three museums." +
                    " In addition to the planetarium. We recommend that you review the library’s cultural program" +
                    " before traveling to learn about the concerts and activities offered by the library and that you can attend.",
                    DestinationID=4,
                },

                new PublicActivity
                {
                    Id=27,
                    Title="Al Montazah Garden\r\n",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-03.jpg",
                    Description="When you think of a beautiful landscape, you imagine beautiful gardens," +
                    " clear skies, and a wonderful view of the sea. Imagine all of this in one place." +
                    " This is actually found in the Montazah Gardens, in addition to the beautiful architecture of the Montazah Palace." +
                    " There you can spend a special day with family or friends and enjoy this special place.",
                    DestinationID=4,
                },

                new PublicActivity
                {
                    Id=28,
                    Title="Walking on the Corniche",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2018/05/Alex-04.jpg",
                    Description="Alexandria Corniche has an atmosphere that distinguishes it from any other place;" +
                    " Whether you are hiking on the Stanley Bridge or drinking a cup of coffee in one of the cafes overlooking the sea." +
                    " You can also rent a boat with your friends and enjoy a cruise in the waters of the Mediterranean Sea, according to the time you want.",
                    DestinationID=4,
                },
                #endregion

                #region Matrouh
                new PublicActivity
                {
                    Id=29,
                    Title="Activities on the seashore",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-activities.jpg",
                    Description="The water of the Mediterranean Sea with the fresh air in the northern coast make this area a special beauty." +
                    " You can enjoy a beautiful day with family or friends in front of the enchanting sea view." +
                    " You can also add some enthusiasm and vitality to your day, the atmosphere there is excellent for practicing all the exciting water sports, " +
                    "water skiing, windsurfing, as well as banana boats.",
                    DestinationID=5,
                },

                new PublicActivity
                {
                    Id=30,
                    Title="Fun parks and water games",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-aqua.jpg",
                    Description="Your vacation in the coast should not be without enjoying the exciting games and water parks offered by some places there." +
                    " Between artificial waves, slides and multiple swimming pools," +
                    " you will have a lot of fun and spend a time full of laughter and fun." +
                    " You can also have meals there and listen to beautiful songs.",
                    DestinationID=5,
                },

                new PublicActivity
                {
                    Id=31,
                    Title="Porto Golf Walk and Shopping",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-portogolf.jpg",
                    Description="Porto Marina promenade is one of the most famous recreational places on the North Coast." +
                    " This place is suitable for the outings of the whole family; It is characterized by multiple restaurants," +
                    " as well as entertainment games for children and adults. But if you want to shop and buy some of your needs of clothes," +
                    " appliances and others, you will also find what you want from different stores and international brands.",
                    DestinationID=5,
                },

                new PublicActivity
                {
                    Id=32,
                    Title="Nightlife",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2019/04/northcoast-nightlife.jpg",
                    Description="Nightlife on the North Coast is one of the most important features that distinguish it from other places." +
                    " If you have spent time relaxing in the morning and want to renew in the evening, you will always find the right place for you." +
                    " The North Coast includes a wide range of restaurants, cafes and cafes that always offer the best offers." +
                    " Be sure to check out the activities and parties so you can book in advance.",
                    DestinationID=5,
                },
                #endregion

                #region Port Said
                new PublicActivity
                {
                    Id=33,
                    Title="Tourist Promenade",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2020/03/01-mamsha.jpg",
                    Description="Hiking on the tourist promenade of the Suez Canal is one of the distinctive experiences that allows you to see a truly unique view." +
                    " An experience you could never have lived before.",
                    DestinationID=9,
                },

                new PublicActivity
                {
                    Id=34,
                    Title="Military Museum",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2020/03/02-mat7af-7arby.jpg",
                    Description="If you hear that Port Said is the valiant city, this is the right time to learn the reason behind this title," +
                    " and of course the Military Museum is the best place that tells the history of the wars that " +
                    "took place on the city’s land in different periods of time through creatively drawn paintings and exhibits of weapons used in wars " +
                    "and other weapons and exhibits that were issued From different missions you tried to assault the city.",
                    DestinationID=9,
                },

                new PublicActivity
                {
                    Id=35,
                    Title="Victory Museum of Modern Art",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2020/03/03-Elnasr-museum.jpg",
                    Description="The Victory Museum is located in one of the most prestigious areas of Port Said below the memorial" +
                    " to the martyrs of the war of 56, which is designed in the form of a pharaonic obelisk. " +
                    "The museum includes 150 works of art by the great artists in Egypt in the field of plastic art from sculpture," +
                    " photography, drawing and crawl on various topics in which modern plastic art merges with " +
                    "historical topics that take interested On a different journey to learn things.",
                    DestinationID=9,
                },

                new PublicActivity
                {
                    Id=36,
                    Title="Tarh Al Bahar Street",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2020/03/04-tarh-el-bahr.jpg",
                    Description="Tarh El Bahr Street extends over a large area in Port Said. It is a distinctive tourist street that " +
                    "includes a large number of free rest houses and gardens, in addition to a number of restaurants," +
                    " cafes and side streets that put you on the sea road to find there the famous fish restaurants and some" +
                    " cafes that offer a unique experience near the seashore full of snails and the For visitors to swim " +
                    "in it and use the seats and parasols provided there.",
                    DestinationID=9,
                },

                new PublicActivity
                {
                    Id=37,
                    Title="Shopping in Port Said",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2020/03/05-shopping.jpg",
                    Description="Your presence in Port Said is an irreplaceable opportunity to shop at low prices for the most" +
                    " famous international brands available for sale in Egypt and from authorized distributors," +
                    " as Port Said is fully famous for the presence of many attractive markets for shoppers," +
                    " but if you are interested in the best experience, El Gomhouria Street will be your first way and then you can tour the " +
                    "city in general And you will find in every inch a convenient place to buy what you need.",
                    DestinationID=9,
                },

                new PublicActivity
                {
                    Id=38,
                    Title="Suburb of Port Fouad",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2020/03/07-port-fouaad.jpg",
                    Description="Port Fouad is reached through ferries that operate throughout the day," +
                    " which is part of the experience of serenity, calmness and splendor located there," +
                    " as it gives you a view of the ships in the Suez Canal amid the seagulls flying around you," +
                    " waiting for the commuters to throw them to and from the suburb of food before you reach Port Fouad itself" +
                    " and enjoy With the green spaces and the beauty of the beaches," +
                    " you will definitely miss a lot if you do not visit it.",
                    DestinationID=9,
                },

                new PublicActivity
                {
                    Id=39,
                    Title="Tenis Island",
                    ImageURL="https://go-bus.com:8181/wp-content/uploads/2020/03/08-Tenis-island.jpg",
                    Description="Tenis Island is located in the southwest of the city of Port Said," +
                    " 9 km from the northeast of Lake Manzala. Easy (in half an hour) and fun (by a \"launch\" boat).",
                    DestinationID=9,
                },
                #endregion

            });
            
        }
    }
}
