using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GoBye.DAL.Data.Models;

namespace GoBye.DAL.Data.Configurations
{
    public class PolicyConfiguration : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.ToTable("Policies");

            
            builder.HasData(new List<Policy>
            {

                #region Policies

                new Policy
                {
                    Id = 1,
                    Title="Consent",
                    Description="By using our website, you hereby consent to our Privacy Policy and agree to its terms."
                },

                new Policy
                {
                    Id = 2,
                    Title="Information we collect",
                    Description="The personal information that you are asked to provide," +
                    " and the reasons why you are asked to provide it," +
                    " will be made clear to you at the point we ask you to provide your personal information." +
                    "If you contact us directly, we may receive additional information about you such as your name," +
                    " email address, phone number, the contents of the message and or attachments you may send us," +
                    " and any other information you may choose to provide.When you register for an Account," +
                    " we may ask for your contact information, including items such as name," +
                    " company name, address, email address, and telephone number."
                },

                new Policy
                {
                    Id = 3,
                    Title="Log Files",
                    Description="Go Bus follows a standard procedure of using log files." +
                    " These files log visitors when they visit websites." +
                    " All hosting companies do this and a part of hosting services’ analytics." +
                    " The information collected by log files include internet protocol (IP) addresses," +
                    " browser type, Internet Service Provider (ISP), date and time stamp, referring/exit pages," +
                    " and possibly the number of clicks. These are not linked to any information that is personally identifiable." +
                    " The purpose of the information is for analyzing trends, administering the site," +
                    " tracking users’ movement on the website, and gathering demographic information."
                },

                new Policy
                {
                    Id = 4,
                    Title="Cookies and Web Beacons",
                    Description="Like any other website, Go Bus uses ‘cookies’." +
                    " These cookies are used to store information including visitors’ preferences," +
                    " and the pages on the website that the visitor accessed or visited." +
                    " The information is used to optimize the users’ experience by customizing " +
                    "our web page content based on visitors’ browser type and/or other information." +
                    "For more general information on cookies, please read “What Are Cookies”."
                },

                new Policy
                {
                    Id = 5,
                    Title="Advertising Partners Privacy Policies",
                    Description="You may consult this list to find the Privacy Policy for each of the advertising partners of Go Bus." +
                    "Third-party ad servers or ad networks use technologies like cookies, JavaScript," +
                    " or Web Beacons that are used in their respective advertisements and links that appear on Go Bus," +
                    " which are sent directly to users’ browsers. They automatically receive your IP address when this occurs." +
                    " These technologies are used to measure the effectiveness of their advertising" +
                    " campaigns and/or to personalize the advertising content that you see on websites that you visit." +
                    "Note that Go Bus has no access to or control over these cookies that are used by third-party advertisers."
                },

                new Policy
                {
                    Id = 6,
                    Title="Third Party Privacy Policies",
                    Description="Go Bus’s Privacy Policy does not apply to other advertisers or websites. Thus, " +
                    "we are advising you to consult the respective Privacy Policies of these third-party ad servers for more detailed information." +
                    " It may include their practices and instructions about how to opt-out of certain options." +
                    "You can choose to disable cookies through your individual browser options." +
                    " To know more detailed information about cookie management with specific web browsers," +
                    " it can be found at the browsers’ respective websites."
                },

                new Policy
                {
                    Id = 7,
                    Title="CCPA Privacy Rights (Do Not Sell My Personal Information)",
                    Description="Under the CCPA, among other rights, California consumers have the right to:Request" +
                    " that a business that collects a consumer’s personal data disclose the categories " +
                    "and specific pieces of personal data that a business has collected about consumers." +
                    "Request that a business delete any personal data about the consumer that a business has collected." +
                    "Request that a business that sells a consumer’s personal data, not sell the consumer’s personal data." +
                    "If you make a request, we have one month to respond to you." +
                    "If you would like to exercise any of these rights, please contact us."
                },

                new Policy
                {
                    Id = 8,
                    Title="Children’s Information",
                    Description="Another part of our priority is adding protection for children while using the internet." +
                    " We encourage parents and guardians to observe, participate in, and/or monitor and guide their online activity." +
                    "Go Bus does not knowingly collect any Personal Identifiable Information from children under the age of 13." +
                    " If you think that your child provided this kind of information on our website," +
                    " we strongly encourage you to contact us immediately and we will do our best efforts to promptly remove such information from our records."
                },
                #endregion

            });
            
        }
    }
}
