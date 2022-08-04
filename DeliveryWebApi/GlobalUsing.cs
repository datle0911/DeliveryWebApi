global using DeliveryWebApi.Domain.Models;
global using DeliveryWebApi.Domain.Models.Enums;
global using DeliveryWebApi.Domain.Models.Notifications;
global using DeliveryWebApi.Domain.Interfaces.Services;
global using DeliveryWebApi.Domain.Interfaces.Repositories;
global using DeliveryWebApi.Infrastructure.Repositories;
global using DeliveryWebApi.Services;
global using DeliveryWebApi.Mqtt;
global using DeliveryWebApi.Mapping;
global using DeliveryWebApi.ViewModels;
global using DeliveryWebApi.ViewModels.OrderViewModels;
global using DeliveryWebApi.ViewModels.OrderDetailViewModels;
global using DeliveryWebApi.ViewModels.ProductViewModels;
global using DeliveryWebApi.ViewModels.UserViewModels;
global using DeliveryWebApi.Hubs;

global using DeliveryWebApi.Identity;
global using DeliveryWebApi.Identity.Helpers;
global using DeliveryWebApi.Identity.ViewModels;

global using AutoMapper;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.JsonPatch;
global using Microsoft.AspNetCore.SignalR;

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
