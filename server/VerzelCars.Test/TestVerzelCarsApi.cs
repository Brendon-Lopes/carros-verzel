using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace VerzelCars.Test;

public class TestVerzelCarsApi : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TestVerzelCarsApi(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory(DisplayName = "Should return status code 200 on GET routes")]
    [InlineData("/api/brands")]
    [InlineData("/api/cars")]
    public async void TestGet(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    }

    [Fact(DisplayName = "Should return status code 200 on login with the correct credentials")]
    public async void TestLogin()
    {
        var client = _factory.CreateClient();

        var data = new {
            email = "admin@mail.com",
            password = "123456"
        };

        var response = await client.PostAsJsonAsync("/api/auth/login", data);

        response.EnsureSuccessStatusCode();
        response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
    }
}
