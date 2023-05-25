using AutoMapper;
using DeliveryParcel.Data;
using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Infrastructure.MapperConfiguration
{
    public class OrderConverter : ITypeConverter<Order, OrderVm>
    {
        public OrderVm Convert(Order source, OrderVm destination, ResolutionContext context)
        {
            destination ??= new OrderVm();

            destination.ShippingDate = source.ShippingDate;
            destination.Id = source.Id;
            destination.SenderFullName = GetSenderFullName(source);
            destination.SenderFullAddress = GetSenderFullAddress(source);
            destination.SenderCity = source.SenderAddress.City.Name;
            destination.RecipientFullName = GetRecipientFullName(source);
            destination.RecipientFullAddress = GetRecipientFullAddress(source);
            destination.RecipientCity = source.RecipientAddress.City.Name;
            destination.Parcel.Wieght = source.Parcel.Weight;

            return destination;
        }

        private static string GetSenderFullName(Order source)
        {
            var fullName = source.Sender.LastName + " " + source.Sender.FirstName;
            if (!string.IsNullOrEmpty(source.Sender.MiddleName))
                fullName += " " + source.Sender.MiddleName;

            return fullName;
        }
            

        private static string GetSenderFullAddress(Order source)
        {
            var senderFullAddress = "ул. " + source.SenderAddress.Street + ", д. " + source.SenderAddress.House + ", эт. " + source.SenderAddress.Flat;
            if (!string.IsNullOrEmpty(source.SenderAddress.Appartament))
                senderFullAddress += ", кв. " + source.SenderAddress.Appartament;

            return senderFullAddress;
        }

        private static string GetRecipientFullName(Order source)
        {
            var fullName = source.Recipient.LastName + " " + source.Recipient.FirstName;
            if (!string.IsNullOrEmpty(source.Recipient.MiddleName))
                fullName += " " + source.Recipient.MiddleName;

            return fullName;
        }
             

        private static string GetRecipientFullAddress(Order source)
        {
            var recipientFullAddress = "ул. " + source.RecipientAddress.Street + ", д. " + source.RecipientAddress.House + ", эт. " + source.RecipientAddress.Flat;
            if (!string.IsNullOrEmpty(source.RecipientAddress.Appartament))
                recipientFullAddress = ", кв. " + source.RecipientAddress.Appartament;

            return recipientFullAddress;
        }
    }
}
